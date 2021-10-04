export class ChatMessage {
    userName: string;
    text: string;
    timeStamp: Date;

    constructor(_userName: string, _text: string, _timeStamp:Date) {
        this.userName = _userName;
        this.text = _text;
        this.timeStamp = _timeStamp;
    }
}