export default class MembershipCard {
    id;
    lockInText;
    price;
    infoSentence;

    constructor(id, lockInText, price, infoSentence) {
        this.id = id;
        this.lockInText = lockInText;
        this.price = price;
        this.infoSentence = infoSentence;
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
}