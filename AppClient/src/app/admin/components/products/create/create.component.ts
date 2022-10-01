import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Product } from 'src/app/contracts/create_product';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private productService : ProductService, private alertify: AlertifyService) { 
    super(spinner);
  }

  ngOnInit(): void {

  }
  @Output() createdProduct : EventEmitter<Create_Product> = new EventEmitter();


   create(name : HTMLInputElement,  price:HTMLInputElement, stock:HTMLInputElement){
    this.showSpinner(SpinnerType.ballAtom);  
    const create_product : Create_Product = new Create_Product();
      create_product.name = name.value;
      create_product.price = parseFloat(price.value);
      create_product.stock = parseInt(stock.value);

      
      this.productService.create(create_product, ()=> {
        this.hideSpinner(SpinnerType.ballAtom);
        this.alertify.message("Product has been successfuly added",{
          dismissOthers: true,
          messageType:MessageType.Success,
          position: Position.TopRight
        });

        this.createdProduct.emit(create_product);
        
      }, errorMessage => {
        this.alertify.message(errorMessage,{
          dismissOthers : true,
          messageType : MessageType.Error,
          position: Position.TopRight

        })

      });
    }

}
