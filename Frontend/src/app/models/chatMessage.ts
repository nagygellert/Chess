import { UserData } from "./userData";

export class ChatMessage {
    user: UserData;
    text: string;
    timeStamp: Date;

    constructor(_user: UserData, _text: string, _timeStamp:Date) {
        this.user = _user;
        this.text = _text;
        this.timeStamp = _timeStamp;
    }
}