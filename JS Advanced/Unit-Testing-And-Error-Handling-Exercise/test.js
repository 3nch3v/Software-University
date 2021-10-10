const { expect } = require('chai');

const isOddOrEven = require('./isOddOrEven.js');

describe('Test funcName for example',  () => {
	it('MyStr should be odd', () => {
		expect(isOddOrEven('MyStr')).to.be.equal('odd');
    });
    it('Just should be even', () => {
		expect(isOddOrEven('Just')).to.be.equal('even');
    });
    it('without parameter should be even', () => {
		expect(isOddOrEven()).to.be.equal(undefined);
    });
});

const lookupChar = require('./lookUpChar.js');

describe('charLookup', () => {
  it('It should return undefined with str 13 and index 0', () => {
    expect(lookupChar(13, 0)).to.be.equal(undefined);
  });

  it('It should return undefined with str "string test" and index "wrong" as a str', () => {
    expect(lookupChar('string test', 'wrong')).to.be.equal(undefined);
  });

  it('It should return undefined with str test and index 2.5', () => {
    expect(lookupChar('Test', 2.5)).to.be.equal(undefined);
  });

  it('It should return "Incorrect index" with str test and index 30', () => {
    expect(lookupChar('Test', 30)).to.be.equal("Incorrect index");
  });

  it('It should return "Incorrect index" with str test and index -3', () => {
    expect(lookupChar('Test', -3)).to.be.equal("Incorrect index");
  });

  it('It should return t with str test and index 3', () => {
    expect(lookupChar('Test', 3)).to.be.equal('t');
  });

  it('It should return e with str "Test str" and index 1', () => {
    expect(lookupChar('Test str', 1)).to.be.equal('e');
  });

  it('It should return undefined with str "string test" and without index', () => {
    expect(lookupChar('string test')).to.be.equal(undefined);
  });

  it('It should return undefined without params', () => {
    expect(lookupChar()).to.be.equal(undefined);
  });
});

const mathEnforcer = require('./mathEnforcer.js');

describe('mathEnforcer', () => {
  describe('addFive', () => {
    it('It should return undefined when the input is not a number', () => {
      expect(mathEnforcer.addFive('Not a num')).to.be.equal(undefined);
    });
    it('It should return 10 when the input is 5', () => {
      expect(mathEnforcer.addFive(5)).to.be.equal(10);
    });
    it('It should return 3 when the input is -2', () => {
      expect(mathEnforcer.addFive(-2)).to.be.equal(3);
    });
    it('It should return 8.3 when the input is 3.3', () => {
      expect(mathEnforcer.addFive(3.3)).to.be.equal(8.3);
    });
    it('It should return 3.3 when the input is 13.3', () => {
      expect(mathEnforcer.addFive(13.3)).to.be.closeTo(18.3, 0.001);
    });
  });

  describe('subtractTen', () => {
    it('It should return undefined when the input is not a number', () => {
      expect(mathEnforcer.subtractTen('Not a num')).to.be.equal(undefined);
    });
    it('It should return 10 when the input is 20', () => {
      expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
    });
    it('It should return -12 when the input is -2', () => {
      expect(mathEnforcer.subtractTen(-2)).to.be.equal(-12);
    });
    it('It should return 3.3 when the input is 13.3', () => {
      expect(mathEnforcer.subtractTen(13.3)).to.be.closeTo(3.3, 0.001);
    });
  });

  describe('sum', () => {
    it('It should return undefined when the input is not a number', () => {
      expect(mathEnforcer.sum('Not a num', 2)).to.be.equal(undefined);
    });
    it('It should return undefined when the input is not a number', () => {
      expect(mathEnforcer.sum(2, 'Not a num')).to.be.equal(undefined);
    });
    it('It should return undefined when the input is missing', () => {
      expect(mathEnforcer.sum()).to.be.equal(undefined);
    });
    it('It should return 10 when the input is 5 and 5', () => {
      expect(mathEnforcer.sum(5, 5)).to.be.equal(10);
    });
    it('It should return 3 when the input is 4 and -1', () => {
      expect(mathEnforcer.sum(4, -1)).to.be.equal(3);
    });
    it('It should return -2 when the input is -1 and -1', () => {
      expect(mathEnforcer.sum(-1, -1)).to.be.equal(-2);
    });
    it('It should return 5.5 when the input is 3.3 and 2.2', () => {
      expect(mathEnforcer.sum(3.3, 2.2)).to.be.equal(5.5);
    });
    it('It should return 3.3 when the input is 13.3 and - 10', () => {
      expect(mathEnforcer.sum(13.3, -10)).to.be.closeTo(3.3, 0.001);
    });
  });
});