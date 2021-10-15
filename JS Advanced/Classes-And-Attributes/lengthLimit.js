class Stringer {
    constructor(str, length) {
        this.innerString = str,
        this.innerLength = length
    }

    increase(length) {
        this.innerLength += length;
    };
    
    decrease(length) {
        this.innerLength - length <= 0 ? this.innerLength = 0 : this.innerLength -= length;
    };

    toString() {
        if(this.innerLength == 0){
            return '...';
        } else {
            return this.innerString.length <= this.innerLength ?  
                        this.innerString : this.innerString.substring(0, this.innerLength) + '...'
        }          
    };
};

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
