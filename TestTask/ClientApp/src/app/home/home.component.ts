import { NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';

var emailValue: any;
var emailIsValid: boolean = false;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  selectedFile!: File;
  userEmail: string = '';

  form: FormGroup = new FormGroup({
    email: new FormControl("", [Validators.required, this.customeEmailValidator])
  })

  getError(control: any): string {
    if (control.errors?.required && control.touched)
      return 'This field is required!';
    else if (control.errors?.emailError && control.touched)
      return 'Please enter valid email address!';
    else return '';
  }

  customeEmailValidator(control: AbstractControl) {
    const pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,20}$/;
    const value = control.value;
    if (!pattern.test(value) && control.touched)
      return {
        emalError: true
      }
    else {
      emailIsValid = true;
      emailValue = value
      return null;
    }
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

  }

  onFileSelected(event: any) {
    this.selectedFile = <File>event.target.files[0];
  }

  onUpload() {
    const apiUrl = 'https://testfunc.azurewebsites.net';

    const filedata = new FormData();
    filedata.append('image', this.selectedFile, this.selectedFile.name);
    this.http.post<{ path: string }>('https://localhost:7000/api/fileupload', filedata)
      .subscribe(res => {
        console.log(res);
        if (emailIsValid)
          this.http.post(apiUrl, { email: this.userEmail }).subscribe(
            (res) => {
              console.log(res);
            });
      })
  }

}


