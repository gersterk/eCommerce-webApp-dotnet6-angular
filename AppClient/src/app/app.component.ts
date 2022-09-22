import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toastr.service';
declare var $: any
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AppClient';

  constructor(private toastrService : CustomToastrService){
    toastrService.message("Hello", "Sores", {
      messageType :ToastrMessageType.Info, 
      position : ToastrPosition.BottomRight
    });
    toastrService.message("Hello", "Sores", {
      messageType :ToastrMessageType.Success, 
      position : ToastrPosition.BottomRight
    });
    toastrService.message("Hello", "Sores", {
      messageType :ToastrMessageType.Warning, 
      position : ToastrPosition.BottomRight
    });
    toastrService.message("Hello", "Sores", {
      messageType :ToastrMessageType.Error, 
      position : ToastrPosition.BottomRight
    });

  }
}

