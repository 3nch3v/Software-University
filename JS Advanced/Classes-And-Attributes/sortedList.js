class List {
    constructor() {
        this._myList = [],
        this.size = 0
    }

    add(number) {
        if(Number.isNaN(number)) {
            throw new Error('Invalid argument exception!');
        }

        this._myList.push(number);
        this._myList.sort((a, b) => a -b);

        this.size++;
    }
    remove(index) {
        if(index < 0 || index >= this._myList.length ) {
            throw new Error('Index out of range!');
        }

        this._myList.splice(index, 1);
        
        this.size--;
    }
    get(index) {
        if(index < 0 || index >= this._myList.length ) {
            throw new Error('Index out of range!');
        }

        return this._myList[index];
    }
}

let list = new List();

list.add(5);
list.add(6);
list.add(7);

console.log(list.get(1)); 

list.remove(1);

console.log(list.get(1));
