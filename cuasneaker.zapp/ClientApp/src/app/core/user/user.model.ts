export interface User {
    id: string;
    name: string;
    email: string;
    avatar?: string;
    status?: string;
    type?: number;
    status_del?: number;
}
export interface sys_user_login_model {
    id: string;
    avatar_path: string;
    last_name: string;
    email: string;
    name: string;
}
