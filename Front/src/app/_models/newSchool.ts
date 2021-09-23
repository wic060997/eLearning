export class NewSchool {
  public name!: string;
  public login!: string;
  public imieNazwisko!: string;
  public password!: string;
  public email!: string;

  constructor(
    name: string,
    login: string,
    imieNazwisko: string,
    password: string,
    email: string
  ){
    this.name = name;
    this.login = login;
    this.imieNazwisko = imieNazwisko;
    this.password = password;
    this.email = email;
  }
}
