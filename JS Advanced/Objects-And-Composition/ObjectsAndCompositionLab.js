//1.	City Record

function solve(name, population, treasury){
    let obj = {
    name: name,
    population: population,
    treasury: treasury,
    };

    return obj;
};

console.log(solve('Tortuga',7000, 15000));

//2.	Town Population

function townPopulation(input){
    let townsData = {};
    for (let i = 0; i < input.length; i++) {
        let [townName, population] = input[i].split(' <-> ');
        if(townName in townsData){
            townsData[townName] += Number(population);
        }else{
            townsData[townName] = Number(population);
        }
    }

    for (const town in townsData) {
        console.log(`${town} : ${townsData[town]}`);
    }
};

townPopulation(['Sofia <-> 1200000', 'Sofia <-> 20000', 'New York <-> 10000000', 'Washington <-> 2345000', 'Las Vegas <-> 1000000']);

//3.	City Taxes

function createCity(name, population, treasury) {
    let result = {
      name: name, 
      population: population, 
      treasury: treasury,
      taxRate: 10,
      collectTaxes() {
        this.treasury += this.population * this.taxRate;
      },
      applyGrowth(percent) {
        this.population += Math.floor(this.population * percent / 100);
      },
      applyRecession(percent) {
        this.treasury -= Math.floor(this.treasury * percent / 100);
      },
    };

    return result;
  }
  
let city = createCity('Tortuga', 7000, 15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);


//4.	Object Factory

function factory(library, orders){
  let result = [];

  for (const order of orders) {
    const currOrder = Object.assign({}, order.template);
    for (const part of order.parts) {
      currOrder[part] = library[part];
    }

    result.push(currOrder);
  };

  return result;
};

const library = {
  print: function () {
    console.log(`${this.name} is printing a page`);
  },
  scan: function () {
    console.log(`${this.name} is scanning a document`);
  },
  play: function (artist, track) {
    console.log(`${this.name} is playing '${track}' by ${artist}`);
  },
};

const orders = [
  {
    template: { name: 'ACME Printer'},
    parts: ['print']      
  },
  {
    template: { name: 'Initech Scanner'},
    parts: ['scan']      
  },
  {
    template: { name: 'ComTron Copier'},
    parts: ['scan', 'print']      
  },
  {
    template: { name: 'BoomBox Stereo'},
    parts: ['play']      
  },
];

const products = factory(library, orders);
console.log(products);
