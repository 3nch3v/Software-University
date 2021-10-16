(function () {
    let myArr = [1, 2, 3, 4, 5];
    
    Array.prototype.last = function() {
        return this[this.length - 1];
    };
    
    Array.prototype.skip = function(elementsCount) {
        return this.slice(elementsCount, this.length);
    };
    
    Array.prototype.take = function(elementsCount) {
        return this.slice(0, elementsCount);
    };
    
    Array.prototype.sum = function() {
        return this.reduce((a, n) => a + n, 0);
    };
    
    Array.prototype.average = function() {
        return this.reduce((a, n) => a + n, 0) / this.length;
    };
})();