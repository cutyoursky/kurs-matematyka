import { Component } from '@angular/core';
import { NgIcon, provideIcons } from '@ng-icons/core';
import { ionCart, ionLogoFacebook } from '@ng-icons/ionicons';

@Component({
  selector: 'app-header',
  imports: [NgIcon],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  providers: [provideIcons({ionLogoFacebook, ionCart})]
})
export class HeaderComponent {}
