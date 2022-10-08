import { Directive, ElementRef, HostListener, Input, Renderer2 } from '@angular/core';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ProductService } from 'src/app/services/common/models/product.service';

declare var $ : any;


@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(
    private element: ElementRef,
    private _renderer: Renderer2,
    private productService : ProductService) 
    
    { 
      const img = _renderer.createElement("img");
      img.setAttribute("src", "../../../../../assets/icon-delete.png");
      img.setAttribute("style", "cursor: pointer;");
      img.height =25;
      img.width = 25;
      _renderer.appendChild(element.nativeElement, img);


    }
    @Input() id:string;
    
    @HostListener("click")
    async onClick(){
      const td : HTMLTableCellElement = this.element.nativeElement;
      await this.productService.delete(this.id);

    $(td.parentElement).fadeOut(1000);


    }

}
