import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public employeeinfo: Iemployeeinfo[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Iemployeeinfo[]>(baseUrl + 'GetEmployeeInfo').subscribe(result => {
      this.employeeinfo = result;
    }, error => console.error(error));
  }
}

interface Iemployeeinfo {
  employee: string,
  company: string
}
