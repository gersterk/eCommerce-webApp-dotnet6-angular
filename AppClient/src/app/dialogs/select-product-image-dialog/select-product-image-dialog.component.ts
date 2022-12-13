import { Component, Inject, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { List_Product_Image } from 'src/app/contracts/list_product_image';
import { FileUploadOptions } from 'src/app/services/common/file-upload/file-upload.component';
import { ProductService } from 'src/app/services/common/models/product.service';
import { BaseDialog } from '../base/base-dialog';

@Component({
  selector: 'app-select-product-image-dialog',
  templateUrl: './select-product-image-dialog.component.html',
  styleUrls: ['./select-product-image-dialog.component.scss']
})
export class SelectProductImageDialogComponent extends BaseDialog<SelectProductImageDialogComponent> implements OnInit{


  constructor(dialogRef : MatDialogRef<SelectProductImageDialogComponent>,

    @Inject(MAT_DIALOG_DATA) public data: SelectProductImageState | string ,
    private productService : ProductService)
    {
    super(dialogRef)
    }



    @Output() options: Partial<FileUploadOptions> ={
      accept : ".png, .jpg, jpeg, .gif" ,
      action : "upload",
      controller : "products",
      explanation : "Choose or drag the product images",
      isAdminPage: true,
      queryString : `id=${this.data}`
    };  
  
    images : List_Product_Image[];
    
  
  async ngOnInit() {
    this.images = await this.productService.readImages(this.data as string);  
  }
}

export enum SelectProductImageState{
  Close
}
function ngOnInit() {
  throw new Error('Function not implemented.');
}

