let count = 0;

class Accountant {
  constructor(fullName, position, salary, childrenQuantity, seniority) {
    this.fullName = fullName;
    this.position = position;
    this.salary = salary;
    this.childrenQuantity = childrenQuantity;
    this.seniority = seniority;
    this.code = ++count;
  }
}

class Accountants {
  constructor() {
    this.accountants = [];
  }

  add(user) {
    if (!(user instanceof Accountant))
      throw `${user} is not an instance of Accountant`;
    this.accountants.push(user);
  }

  getById(id) {
    return this.accountants.find(user => user.code === id);
  }

  update(id, newUser) {
    let user = this.getById(id);
    if (!user)
      throw "Not found";
    for (let k of ["fullName", "position", "salary", "childrenQuantity", "seniority"]) {
      if (newUser[k])
        user[k] = newUser[k];
    }
  }

  delete(id) {
    let userIndex = this.accountants.findIndex(user => user.code === id);
    if (userIndex === -1)
      throw "Not found";
    this.accountants.splice(userIndex, 1);
  }

  getByPosition(position) {
    return this.accountants.filter(user => user.position.toLowerCase() === position.toLowerCase());
  }

  getByChildren(childrenQuantity) {
    return this.accountants.filter(user => Number(user.childrenQuantity) >= Number(childrenQuantity));
  }
}

let firstUser = new Accountant("Новікова Руслана", "Студент", 0, 0, "1 курс");
let secondUser = new Accountant("Ромочівська Марія", "Перекладач", 0, 1, "1 клас");
let accountants = new Accountants();
accountants.add(firstUser);
accountants.add(secondUser);
accountants.getByPosition("");
accountants.getByChildren("1")
