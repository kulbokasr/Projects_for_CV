import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ShopCreate from '../models/shop-create.model';
import Shop from '../models/shop.model';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private httpClient: HttpClient) { }


  public getAllShops(): Observable<Shop[]>{
    return this.httpClient.get<Shop[]>("https://localhost:44323/shop");
  }

  public createShop(shopCreate: ShopCreate) : Observable<any> {
    return this.httpClient.post("https://localhost:44323/shop", shopCreate)
  }

  public deleteShop(id: number) : Observable<any> {
    return this.httpClient.delete("https://localhost:44323/shop/"+id)
  }

  public updateShop(id: number, shop : Shop) : Observable<any> {
    return this.httpClient.put("https://localhost:44323/shop/"+id, shop)
  }


}
