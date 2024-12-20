import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatCard } from '@angular/material/card';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule, MatCard,
    MatFormField, MatInput,
    MatLabel, MatButton
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent {
  private fb = inject(FormBuilder)
  private accountServices = inject(AccountService)
  private router = inject(Router)

  loginForm = this.fb.group({
    email: [''],
    password: ['']
  })

  onSubmit(){
    this.accountServices.login(this.loginForm.value).subscribe({
      next: () =>{
        this.accountServices.getUserInfo();
        this.router.navigateByUrl('/shop');
      }
    })
  }
}
