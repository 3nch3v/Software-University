function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let input = JSON.parse(document.querySelector('textarea').value);
      let restourants = [];

      input.forEach(r => {
         let [currName, workers] = r.split(' - ');
         let workersData = workers.split(', ');

         let workersObj = [];

         workersData.forEach((w) => {
            let [name, salary] = w.split(' ');
            workersObj.push({
               name,
               salary: Number(salary)
            })
         });

         let avg = workersObj.reduce(function (sum, value) {
            return sum + value.salary;
        }, 0) / workersObj.length;

         let bestSalary = workersObj.sort((a, b) => b.salary - a.salary)[0];

        let currRestourant = {
         restourantName: currName,
         avgSalary: avg,
         bestSalary: bestSalary.salary,
         workers: workersObj.sort(function(a, b) {
            return b.salary - a.salary;
        })};

        if(restourants.some((r) => r.restourantName === currName)) {
            restourants = restourants.filter((r) => r.restourantName !== currName);
            restourants.push(currRestourant);
        } else {
            restourants.push(currRestourant);
        }
      });

      let bestRestourant = restourants.sort((a , b) => b.avgSalary - a.avgSalary)[0];

      let restourantOutput = document.querySelector('#bestRestaurant p');
      restourantOutput.textContent = `Name: ${bestRestourant.restourantName} Average Salary: ${bestRestourant.avgSalary.toFixed(2)} Best Salary: ${bestRestourant.bestSalary.toFixed(2)}`
      
      let workersOutput = document.querySelector('#workers p');
      bestRestourant.workers.forEach((w) => { workersOutput.textContent += `Name: ${w.name} With Salary: ${w.salary} `})
   }
}