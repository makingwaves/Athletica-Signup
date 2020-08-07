export default class MembershipCard {
    id;
    lockInText;
    price;
    infoSentence;
    boxLabel;

    constructor(id, lockInText, price, infoSentence, boxLabel) {
        this.id = id;
        this.lockInText = lockInText;
        this.price = price;
        this.infoSentence = infoSentence;
        this.boxLabel = boxLabel;
    }

    getId() {
        return this.id;
    }

    getLockInText() {
        return this.lockInText;
    }

    getPrice() {
        return this.price;
    }

    getInfoSentence() {
        return this.infoSentence;
    }

    getLabel() {
        return this.label;
    }
}