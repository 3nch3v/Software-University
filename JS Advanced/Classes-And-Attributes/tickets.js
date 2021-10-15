function solve(tickets, sortingCriterion) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination,
            this.price = price,
            this.status = status
        }
    }

    let result = [];

    tickets.forEach(t => {
        let [destination, price, status] = t.split('|');
        result.push(new Ticket(destination, Number(price), status));
    });

    result =  result.sort((a, b) => {
        if(sortingCriterion === 'destination' || sortingCriterion === 'status') {
            return sortingCriterion === 'destination' ? 
                    a.destination.localeCompare(b.destination) : a.status.localeCompare(b.status);
        } else {
            return a.price - b.price;
        }
    });

    return result;
}

console.log(solve(['Philadelphia|94.20|available',
                   'New York City|95.99|available',
                   'New York City|95.99|sold',
                   'Boston|126.20|departed'],
                   'destination'
));