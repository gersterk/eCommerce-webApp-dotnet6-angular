import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';
import { HttpClientService } from '../http-client.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {
  constructor(private httpclientService : HttpClientService) 
  {  }

    public files: NgxFileDropEntry[] = [];

    @Input() options : Partial<FileUploadOptions>;

  public selectedFiles(files: NgxFileDropEntry[]) {
    this.files = files;

  const fileData : FormData = new FormData();
    for(const file of files){
    (file.fileEntry as FileSystemFileEntry).file((_file:File)=>{
      fileData.append(_file.name, _file, file.relativePath);

    });

  }
    this.httpclientService.post({
      controller: this.options.controller,
      action : this.options.action,
      queryString : this.options.queryString,
      headers : new HttpHeaders({"responseType" : "blob"})

    }, fileData).subscribe(data=>{

    }, (errorResponse : HttpErrorResponse) =>{
      
    });


  }

}


export class FileUploadOptions{
  controller? : string;
  action? : string;
  queryString? : string;
  explanation? : string;
  accept? : string;


 }