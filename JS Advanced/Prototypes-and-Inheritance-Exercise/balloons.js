function solve() {
    class Balloon {
        constructor(color, hasWeight) {
            this.color = color,
            this.hasWeight = hasWeight
        }
    }
    
    class PartyBalloon extends Balloon {
        constructor(color, hasWeight, ribbonColor, ribbonLength) {
            super(color, hasWeight)
            this.ribbon = {
                color: ribbonColor,
                length: ribbonLength
            }
        }
    
        get() {
            return this.ribbon;
        }
    }
    
    class BirthdayBalloon extends PartyBalloon {
        constructor(color, hasWeight, ribbonColor, ribbonLength, text) {
            super(color, hasWeight, ribbonColor, ribbonLength)
            this.text = text
        }
    
        get() {
            return this.text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
};