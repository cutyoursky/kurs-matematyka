import { Component } from '@angular/core';
import { MainComponent } from "./main/main.component";
import { LayoutComponent } from "../../shared/layout/layout.component";

@Component({
  selector: 'app-home',
  imports: [MainComponent, LayoutComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
