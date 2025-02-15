import { Component, EventEmitter, Output } from '@angular/core';
import { TuiButton } from '@taiga-ui/core';
import { TuiSwitch } from '@taiga-ui/kit';

@Component({
  selector: 'app-header',
  imports: [TuiButton, TuiSwitch],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

}
