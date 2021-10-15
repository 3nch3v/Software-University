class Company {
    constructor() {
        this.departments = {}
    }

    addEmployee(...args) {
        let [name, salary, position, department] = Array.from(args);

        if(args.some(a => a === null || a === '' || a === undefined) 
           || salary < 0) {

            throw new Error('Invalid input!');
        }

        if(!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];    
        }

        this.departments[department].push({
            name,
            salary,
            position
        });

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = [];
        let currAvg = 0;

        for(const department in this.departments) {
            const departmentData = this.departments[department];
            let avg = departmentData.reduce((acc, empl) => acc + empl.salary, 0) / departmentData.length;
            
            if(avg > currAvg) {
                currAvg = avg;
                bestDepartment.push(`Best Department is: ${department}`);
                bestDepartment.push(`Average salary: ${currAvg.toFixed(2)}`);
                departmentData.sort((a, b) => { 
                    return b.salary - a.salary || a.name.localeCompare(b.name);
                }).forEach(empl => {
                    bestDepartment.push(`${empl.name} ${empl.salary} ${empl.position}`);
                });
            }
        }

       return bestDepartment.join('\n');
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
