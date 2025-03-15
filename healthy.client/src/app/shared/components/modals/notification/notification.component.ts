import { Component } from '@angular/core';

@Component({
  selector: 'app-notification',
  standalone: false,
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css'
})
export class NotificationComponent {
  isSuccess: boolean = true;
  title: string = '';
  message: string = '';

 // constructor (public bsModalRef: BsModalRef) {} importálni kell az ngx et 
}
