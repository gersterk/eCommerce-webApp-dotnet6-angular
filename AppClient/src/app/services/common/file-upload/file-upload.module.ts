import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadComponent } from './file-upload.component';
import { NgxFileDropModule } from 'ngx-file-drop';
import { DialogModule } from '../../../dialogs/dialog.module';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    FileUploadComponent
  ],
  imports: [
    CommonModule,
    NgxFileDropModule,
    DialogModule,
    ToastrModule
    
  ],
  exports:[
    FileUploadComponent
  ]
})
export class FileUploadModule { }
