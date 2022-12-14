import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { Create_Product } from 'src/app/contracts/create_product';
import { List_Product } from 'src/app/contracts/list_products';
import { HttpClientService, RequestParameters } from '../http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService : HttpClientService) { }

  create(product : Create_Product, successCallBack?: () => void, errorCallBack?: (errorMessage : string)=> void){

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
      async read(page:number = 0, size :number= 5, successCallBack? : () => void, errorCallBack? : (errorMessage:string)=> void) : Promise<{totalCount : number; products : List_Product[]}>{
      const promiseData : Promise<{totalCount : number; products : List_Product[]}> =  this.httpClientService.get<{totalCount : number; products : List_Product[]}>({
        controller : "products",
        queryString : `page= ${page}&size=${size}` 

      }).toPromise();

      promiseData.then(d => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message))
      return await promiseData;
    }
 
  async delete(id:string){
     const deleteObservable: Observable<any> = this.httpClientService.delete<any>({
      controller: "products"
    }, id );

    await firstValueFrom(deleteObservable);

  }

  async readImages(id:string) : Promise<List_Product_Image[]>{
    //Observable should be pointed and if could why not type-safe :)

    const getObservable : Observable<List_Product_Image[]> =  this.httpClientService.get<List_Product_Image[]>({
      action: "getproductimages",  //action names arent case sensitive
      controller : "products"

    }, id);

    return await firstValueFrom(getObservable)

    //the func must return something because it promise an array of LPI
  }

}
