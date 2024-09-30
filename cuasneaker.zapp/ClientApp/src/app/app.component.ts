import { Component, Inject } from '@angular/core';
import { AngularFirestore } from '@angular/fire/firestore';
import moment from 'moment';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { MessagingService } from './core/firebase/messaging.service';
import { sub_device, token_noti_user } from './core/models/firebase_model';
import { User } from './core/user/user.model';
import { UserService } from './core/user/user.service';
import { DeviceUUID } from 'device-uuid';
import { TranslocoService } from '@ngneat/transloco';
import { RxState } from '@rx-angular/state';
import {
    CARD_STATE,
    CardState,
} from './modules/common-model/states/card.state';
import { portal_san_pham_chi_tiet_card_model } from './modules/portal/portal.types';
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent {
    title = 'push-notification';
    message;
    user: User;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * Constructor
     */
    constructor(
        private messagingService: MessagingService,
        @Inject(CARD_STATE) private cardPageState: RxState<CardState>,
        private db: AngularFirestore,
        private _userService: UserService,
        private translocoService: TranslocoService
    ) {
        this._userService.user$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((user: User) => {
                this.user = user;
                let id_device = new DeviceUUID().get();
                const listDB = this.db
                    .collection('token_noti_user')
                    .valueChanges();
                let idUser = window.location.host + user.id;
                // create new subdevice
                let du = new DeviceUUID().parse();
                let subDevice: sub_device = {
                    date_sign_in: moment().valueOf(),
                    device_id: id_device,
                    device_name: du.os,
                    device_type: du.platform,
                    device_version: du.version,
                    status: 1,
                    token_firebase: localStorage.getItem('token_firebase'),
                };
                // Find user is existed ?
                listDB.subscribe(async (users: token_noti_user[]) => {
                    let found = false;
                    for (var i = 0; i < users.length; i++) {
                        if (users[i].id === idUser) {
                            found = true;
                            break;
                        }
                    }
                    if (found == false) {
                        // create new user
                        let token_user: token_noti_user = {
                            id: window.location.host + user.id,
                            create_upDate: moment().toISOString(),
                            domain: window.location.host,
                            date_upDate: moment().toISOString(),
                            user_id: user.id,
                            user_name: user.name,
                            count_notification: 0,
                            token_firebase:
                                localStorage.getItem('token_firebase'),
                        };

                        // add document
                        await this.db
                            .collection(`token_noti_user`)
                            .doc(idUser)
                            .set(token_user);
                        // add subcollection
                        await this.db
                            .collection(`token_noti_user/${idUser}/sub_device`)
                            .doc(subDevice.device_id)
                            .set(subDevice);
                    } else if (found == true) {
                        // check subdeive is existed ?
                        this.db
                            .collection(`token_noti_user/${idUser}/sub_device`)
                            .valueChanges()
                            .subscribe(async (devices: sub_device[]) => {
                                let foundDevice = false;
                                let isTokenNull = false;
                                for (var i = 0; i < devices.length; i++) {
                                    if (devices[i].device_id === id_device) {
                                        foundDevice = true;
                                        isTokenNull =
                                            devices[i].token_firebase == 'null';
                                        break;
                                    }
                                }
                                if (foundDevice === false) {
                                    await this.db
                                        .collection(
                                            `token_noti_user/${idUser}/sub_device`
                                        )
                                        .doc(subDevice.device_id)
                                        .set(subDevice);
                                }
                                if (
                                    foundDevice === true &&
                                    isTokenNull == true
                                ) {
                                    await this.db
                                        .collection(
                                            `token_noti_user/${idUser}/sub_device`
                                        )
                                        .doc(subDevice.device_id)
                                        .update({
                                            token_firebase:
                                                subDevice.token_firebase,
                                        });
                                }
                            });
                    }
                });
            });
    }

    ngOnInit() {
        this.messagingService.requestPermission();
        this.messagingService.receiveMessage();
        this.message = this.messagingService.currentMessage;
    }
}
