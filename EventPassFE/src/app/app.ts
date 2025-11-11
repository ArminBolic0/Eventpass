import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./shared/header/header";
import { RegisterComponent } from "./features/auth/register/register";
import { FooterComponent } from "./shared/footer/footer";


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, RegisterComponent, FooterComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'EventPassFE';
}
