export {};

// 1. Base Class: Employee
class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    // Constructor
    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    // 2. Getter
    public getSalary(): number {
        return this.salary;
    }

    // 2. Setter with validation
    public setSalary(value: number): void {
        if (value > 0) {
            this.salary = value;
        } else {
            console.log("Salary must be greater than 0");
        }
    }

    // 3. Method
    public displayDetails(): void {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}

// 4. Derived Class: Manager
class Manager extends Employee {
    public teamSize: number;

    // Constructor using super
    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }

    // 5. Method Overriding
    public displayDetails(): void {
        super.displayDetails(); // call base method
        console.log(`Team Size: ${this.teamSize}`);
    }
}

// 6. Object Creation

// Employee object
const emp = new Employee(1, "Geetha", 30000);
emp.displayDetails();

console.log("Updated Salary:");
emp.setSalary(35000);
console.log(emp.getSalary());

// Manager object
const mgr = new Manager(2, "Ravi", 50000, 5);
mgr.displayDetails();