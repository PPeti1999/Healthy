import { Injectable } from '@angular/core';
import { NotificationComponent } from './components/modals/notification/notification.component';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

 /* bsModalRef?: BsModalRef;                                    NGX kell
  displayingExpiringSessionModal = false;

  constructor(private modalService: BsModalService) { }

  showNotification(isSuccess: boolean, title: string, message: string) {
    const initalState: ModalOptions = {
      initialState: {
        isSuccess,
        title,
        message
      }
    };

    this.bsModalRef = this.modalService.show(NotificationComponent, initalState);
  }

  openExpiringSessionCountdown = async () => {
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      ignoreBackdropClick: true
    }

    
  }*/
}
