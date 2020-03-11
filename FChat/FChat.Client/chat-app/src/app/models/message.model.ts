import { UserModel } from './user.model';

export class MessageModel{
    id: number;
    message: string; 
    user: UserModel;
    groupTypeId: number;
    createdOn: string;
}