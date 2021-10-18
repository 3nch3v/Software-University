class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName,
        this.ticketPrice = Number(ticketPrice),
        this.screenings = [],
        this._profit = 0;
        this._soldTicketsCount = 0;
    }

    newScreening(date, hall, description) {
        if(this.screenings.some(m => m.date === date && m.hall === hall)) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        }

        this.screenings.push({
            date,
            hall,
            description
        });
        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets)  {
        if(this.screenings.some(m => m.date === date && m.hall === hall)) {
            this.screenings = this.screenings.filter(m => m.hall !== hall || m.date !== date);

            let currentProfit = soldTickets * this.ticketPrice;
            this._profit += currentProfit
            this._soldTicketsCount += soldTickets;

            return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}`;
        } else {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }
    }

    toString() {
        let output = [];
        output.push(`${this.movieName} full information:`)
        output.push(`Total profit: ${this._profit.toFixed(0)}$`);
        output.push(`Sold Tickets: ${this._soldTicketsCount}`);

        if(this.screenings.length > 0){
            output.push(`Remaining film screenings:`)
            this.screenings
                .sort((a, b) => a.hall.localeCompare(b.hall))
                .forEach(scr => output.push(`${scr.hall} - ${scr.date} - ${scr.description}`));
        } else {
            output.push('No more screenings!');
        }

        return output.join('\n');
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));

console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));

console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());
