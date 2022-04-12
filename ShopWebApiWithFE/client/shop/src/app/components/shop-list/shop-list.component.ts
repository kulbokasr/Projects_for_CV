import { Component, OnInit } from '@angular/core';
import ShopCreate from 'src/app/models/shop-create.model';
import Shop from 'src/app/models/shop.model';
import { ShopService } from 'src/app/services/shop.service';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.scss']
})
export class ShopListComponent implements OnInit {

  constructor(private shopService : ShopService) { }
  public shop : Shop = {} as Shop
  public shops : Shop[] = []
  public shopCreate : ShopCreate = {} as ShopCreate
  ngOnInit(): void {
    this.shopService.getAllShops().subscribe((shops) => {
      this.shops = shops;
    });
  }
  deleteShop(id:number){
    this.shopService.deleteShop(id).subscribe(log => console.log('deleted '+id))
    location.reload();
  }

  updateShop(id:number, title : string){
    this.shop.name = title
    this.shopService.updateShop(id, this.shop).subscribe(log => console.log('updated '+id))
    this.shop.tempName = ''
    location.reload();
  }
}
