import {
    ChangeDetectionStrategy,
    ChangeDetectorRef,
    Component,
    ElementRef,
    OnDestroy,
    OnInit,
    Renderer2,
    TemplateRef,
    ViewChild,
    ViewContainerRef,
    ViewEncapsulation,
} from '@angular/core';
import {
    ActivatedRoute,
    ActivatedRouteSnapshot,
    Router,
    RouterStateSnapshot,
} from '@angular/router';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TemplatePortal } from '@angular/cdk/portal';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { MatDrawerToggleResult } from '@angular/material/sidenav';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, debounceTime, takeUntil } from 'rxjs/operators';
import { ContactsService } from '../contacts.service';
import { Tag, Contact, Country } from '../contacts.types';
import { ContactsListComponent } from '../list/list.component';
import { FuseConfirmationService } from '@fuse/services/confirmation';
import { HttpClient, HttpEventType } from '@angular/common/http';
import Swal from 'sweetalert2';

@Component({
    selector: 'contacts-details',
    templateUrl: './details.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ContactsDetailsComponent implements OnInit, OnDestroy {
    @ViewChild('avatarFileInput') private _avatarFileInput: ElementRef;
    @ViewChild('tagsPanel') private _tagsPanel: TemplateRef<any>;
    @ViewChild('tagsPanelOrigin') private _tagsPanelOrigin: ElementRef;

    editMode: boolean = false;
    tags: Tag[];
    tagsEditMode: boolean = false;
    filteredTags: Tag[];
    contact: Contact;
    contactForm: FormGroup;
    contacts: Contact[];
    countries: Country[];
    private _tagsPanelOverlayRef: OverlayRef;
    private _unsubscribeAll: Subject<any> = new Subject<any>();

    /**
     * Constructor
     */
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _changeDetectorRef: ChangeDetectorRef,
        private _contactsListComponent: ContactsListComponent,
        private _contactsService: ContactsService,
        private _formBuilder: FormBuilder,
        private _renderer2: Renderer2,
        private _router: Router,
        private _overlay: Overlay,
        private http: HttpClient,
        // private _fuseConfirmationService: FuseConfirmationService,
        private _viewContainerRef: ViewContainerRef
    ) {}

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this._contactsListComponent.matDrawer.open();

        // Get the contacts
        this._contactsService.contacts$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((contacts: Contact[]) => {
                this.contacts = contacts;

                // Mark for check
                this._changeDetectorRef.markForCheck();
            });

        // Get the contact
        this._contactsService.contact$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((contact: Contact) => {
                // Open the drawer in case it is closed
                this._contactsListComponent.matDrawer.open();

                // Get the contact
                this.contact = contact;

                // Toggle the edit mode off
                this.toggleEditMode(false);

                // Mark for check
                this._changeDetectorRef.markForCheck();
            });
        // Get the tags
        this._contactsService.tags$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((tags: Tag[]) => {
                this.tags = tags;
                this.filteredTags = tags;

                // Mark for check
                this._changeDetectorRef.markForCheck();
            });
    }
    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();

        // Dispose the overlays if they are still on the DOM
        if (this._tagsPanelOverlayRef) {
            this._tagsPanelOverlayRef.dispose();
        }
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Close the drawer
     */
    closeDrawer(): Promise<MatDrawerToggleResult> {
        return this._contactsListComponent.matDrawer.close();
    }

    /**
     * Toggle edit mode
     *
     * @param editMode
     */
    toggleEditMode(editMode: boolean | null = null): void {
        if (editMode === null) {
            this.editMode = !this.editMode;
        } else {
            this.editMode = editMode;
        }
        // Mark for check
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Update the contact
     */
    updateContact(): void {
        // Get the contact object
        const contact = this.contactForm.getRawValue();

        // Go through the contact object and clear empty values
        contact.emails = contact.emails.filter((email) => email.email);

        contact.phoneNumbers = contact.phoneNumbers.filter(
            (phoneNumber) => phoneNumber.phoneNumber
        );

        // Update the contact on the server
        this._contactsService
            .updateContact(contact.id, contact)
            .subscribe(() => {
                // Toggle the edit mode off
                this.toggleEditMode(false);
            });
    }

    /**
     * Delete the contact
     */
    deleteContact(): void {
        // Open the confirmation dialog
        // const confirmation = this._fuseConfirmationService.open({
        //     title: 'Confirm action',
        //     message: 'Are you sure you want to confirm this action?',
        //     icon: {
        //         show: true,
        //         name: 'heroicons_outline:exclamation',
        //         color: 'warn',
        //     },
        //     actions: {
        //         confirm: {
        //             show: true,
        //             label: 'Confirm',
        //             color: 'warn',
        //         },
        //         cancel: {
        //             show: true,
        //             label: 'Cancel',
        //         },
        //     },
        //     dismissible: false,
        // });
        // Subscribe to the confirmation dialog closed action
        // confirmation.afterClosed().subscribe((result) => {
        //     // If the confirm button pressed...
        //     if (result === 'confirmed') {
        //         // Get the current contact's id
        //         const id = this.contact.id;
        //         // Get the next/previous contact's id
        //         const currentContactIndex = this.contacts.findIndex(
        //             (item) => item.id === id
        //         );
        //         const nextContactIndex =
        //             currentContactIndex +
        //             (currentContactIndex === this.contacts.length - 1 ? -1 : 1);
        //         const nextContactId =
        //             this.contacts.length === 1 && this.contacts[0].id === id
        //                 ? null
        //                 : this.contacts[nextContactIndex].id;
        //         // Delete the contact
        //         this._contactsService
        //             .deleteContact(id)
        //             .subscribe((isDeleted) => {
        //                 // Return if the contact wasn't deleted...
        //                 if (!isDeleted) {
        //                     return;
        //                 }
        //                 // Navigate to the next contact if available
        //                 if (nextContactId) {
        //                     this._router.navigate(['../', nextContactId], {
        //                         relativeTo: this._activatedRoute,
        //                     });
        //                 }
        //                 // Otherwise, navigate to the parent
        //                 else {
        //                     this._router.navigate(['../'], {
        //                         relativeTo: this._activatedRoute,
        //                     });
        //                 }
        //                 // Toggle the edit mode off
        //                 this.toggleEditMode(false);
        //             });
        //         // Mark for check
        //         this._changeDetectorRef.markForCheck();
        //     }
        // });
    }

    /**
     * Upload avatar
     *
     * @param fileList
     */
    uploadAvatar(fileList: FileList): void {
        // Return if canceled
        if (!fileList.length) {
            return;
        }

        const allowedTypes = ['image/jpeg', 'image/png'];
        const file = fileList[0];

        // Return if the file is not allowed
        if (!allowedTypes.includes(file.type)) {
            return;
        }

        // Upload the avatar
        this._contactsService.uploadAvatar(this.contact.id, file).subscribe();
        var formData = new FormData();
        for (var i = 0; i < fileList.length; i++) {
            var extension = fileList[0].type;
            if (fileList[0].size > 15728640) {
                alert('File upload không được quá 15 Mb!');
                return;
            }
            formData.append('list_file[]', fileList[i]);
        }
        this.http
            .post('FileManager/uploadimage', formData, {
                // reportProgress: true,
                // observe: 'events',
            })
            .subscribe((res) => {
                var data: any;
                data = res;
                this.contact.avatar = data.location.file_path as any;
                this._changeDetectorRef.markForCheck();
            });
    }

    /**
     * Remove the avatar
     */
    removeAvatar(): void {
        // Get the form control for 'avatar'
        const avatarFormControl = this.contactForm.get('avatar');

        // Set the avatar as null
        avatarFormControl.setValue(null);

        // Set the file input value as null
        this._avatarFileInput.nativeElement.value = null;

        // Update the contact
        this.contact.avatar = null;
    }

    /**
     * Open tags panel
     */
    openTagsPanel(): void {
        // Create the overlay
        this._tagsPanelOverlayRef = this._overlay.create({
            backdropClass: '',
            hasBackdrop: true,
            scrollStrategy: this._overlay.scrollStrategies.block(),
            positionStrategy: this._overlay
                .position()
                .flexibleConnectedTo(this._tagsPanelOrigin.nativeElement)
                .withFlexibleDimensions(true)
                .withViewportMargin(64)
                .withLockedPosition(true)
                .withPositions([
                    {
                        originX: 'start',
                        originY: 'bottom',
                        overlayX: 'start',
                        overlayY: 'top',
                    },
                ]),
        });

        // Subscribe to the attachments observable
        this._tagsPanelOverlayRef.attachments().subscribe(() => {
            // Add a class to the origin
            this._renderer2.addClass(
                this._tagsPanelOrigin.nativeElement,
                'panel-opened'
            );

            // Focus to the search input once the overlay has been attached
            this._tagsPanelOverlayRef.overlayElement
                .querySelector('input')
                .focus();
        });

        // Create a portal from the template
        const templatePortal = new TemplatePortal(
            this._tagsPanel,
            this._viewContainerRef
        );

        // Attach the portal to the overlay
        this._tagsPanelOverlayRef.attach(templatePortal);

        // Subscribe to the backdrop click
        this._tagsPanelOverlayRef.backdropClick().subscribe(() => {
            // Remove the class from the origin
            this._renderer2.removeClass(
                this._tagsPanelOrigin.nativeElement,
                'panel-opened'
            );

            // If overlay exists and attached...
            if (
                this._tagsPanelOverlayRef &&
                this._tagsPanelOverlayRef.hasAttached()
            ) {
                // Detach it
                this._tagsPanelOverlayRef.detach();

                // Reset the tag filter
                this.filteredTags = this.tags;

                // Toggle the edit mode off
                this.tagsEditMode = false;
            }

            // If template portal exists and attached...
            if (templatePortal && templatePortal.isAttached) {
                // Detach it
                templatePortal.detach();
            }
        });
    }

    /**
     * Toggle the tags edit mode
     */
    toggleTagsEditMode(): void {
        this.tagsEditMode = !this.tagsEditMode;
    }

    /**
     * Filter tags
     *
     * @param event
     */
    filterTags(event): void {
        // Get the value
        const value = event.target.value.toLowerCase();

        // Filter the tags
        this.filteredTags = this.tags.filter((tag) =>
            tag.title.toLowerCase().includes(value)
        );
    }

    /**
     * Filter tags input key down event
     *
     * @param event
     */
    filterTagsInputKeyDown(event): void {
        // Return if the pressed key is not 'Enter'
        if (event.key !== 'Enter') {
            return;
        }

        // If there is no tag available...
        if (this.filteredTags.length === 0) {
            // Create the tag
            this.createTag(event.target.value);

            // Clear the input
            event.target.value = '';

            // Return
            return;
        }

        // If there is a tag...
        const tag = this.filteredTags[0];
        const isTagApplied = this.contact.tags.find((id) => id === tag.id);

        // If the found tag is already applied to the contact...
        if (isTagApplied) {
            // Remove the tag from the contact
            this.removeTagFromContact(tag);
        } else {
            // Otherwise add the tag to the contact
            this.addTagToContact(tag);
        }
    }

    /**
     * Create a new tag
     *
     * @param title
     */
    createTag(title: string): void {
        const tag = {
            title,
        };

        // Create tag on the server
        this._contactsService.createTag(tag).subscribe((response) => {
            // Add the tag to the contact
            this.addTagToContact(response);
        });
    }

    /**
     * Update the tag title
     *
     * @param tag
     * @param event
     */
    updateTagTitle(tag: Tag, event): void {
        // Update the title on the tag
        tag.title = event.target.value;

        // Update the tag on the server
        this._contactsService
            .updateTag(tag.id, tag)
            .pipe(debounceTime(300))
            .subscribe();

        // Mark for check
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Delete the tag
     *
     * @param tag
     */
    deleteTag(tag: Tag): void {
        // Delete the tag from the server
        this._contactsService.deleteTag(tag.id).subscribe();

        // Mark for check
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Add tag to the contact
     *
     * @param tag
     */
    addTagToContact(tag: Tag): void {
        // Add the tag
        this.contact.tags.unshift(tag.id);

        // Update the contact form
        this.contactForm.get('tags').patchValue(this.contact.tags);

        // Mark for check
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Remove tag from the contact
     *
     * @param tag
     */
    removeTagFromContact(tag: Tag): void {
        // Remove the tag
        this.contact.tags.splice(
            this.contact.tags.findIndex((item) => item === tag.id),
            1
        );

        // Update the contact form
        this.contactForm.get('tags').patchValue(this.contact.tags);

        // Mark for check
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Toggle contact tag
     *
     * @param tag
     */
    toggleContactTag(tag: Tag): void {
        if (this.contact.tags.includes(tag.id)) {
            this.removeTagFromContact(tag);
        } else {
            this.addTagToContact(tag);
        }
    }

    /**
     * Should the create tag button be visible
     *
     * @param inputValue
     */
    shouldShowCreateTagButton(inputValue: string): boolean {
        return !!!(
            inputValue === '' ||
            this.tags.findIndex(
                (tag) => tag.title.toLowerCase() === inputValue.toLowerCase()
            ) > -1
        );
    }
    /**
     * Track by function for ngFor loops
     *
     * @param index
     * @param item
     */
    trackByFn(index: number, item: any): any {
        return item.id || index;
    }
}
