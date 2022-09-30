import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Create_Product } from 'src/app/contracts/create_product';
import { List_Product } from 'src/app/contracts/list_products';
import { HttpClientService } from '../http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService : HttpClientService) { }

  create(product : Create_Product, successCallBack? : any, errorCallBack?: (errorMessage : string)=> void){

    this.httpClientService.post({
      controller: "products"

    }, product).subscribe(result => {
      successCallBack();
      alert("successful");
    }, (errorRespone:HttpErrorResponse) =>{
      const _error : Array<{key:string, value: Array<string>}>= errorRespone.error;
      let message = "";
      _error.forEach((v, index)=>{
        v.value.forEach((_v, _index)=>{
          message += `${_v}<br>`;

        });

      });
      errorCallBack(message);
    });

 
  }
      async read(page:number = 0, size :number= 5, successCallBack? : () => void, errorCallBack? : (errorMessage:string)=> void) : Promise<List_Product[]>{
      const promiseData : Promise<List_Product[]> =  this.httpClientService.get<List_Product[]>({
        controller : "products"
      }).toPromise();

      promiseData.then(d => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message))
      return await promiseData;
    }
}
