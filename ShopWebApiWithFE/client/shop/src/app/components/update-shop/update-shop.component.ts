import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Shop from 'src/app/models/shop.model';
import { ShopService } from 'src/app/services/shop.service';

@Component({
  selector: 'app-update-shop',
  templateUrl: './update-shop.component.html',
  styleUrls: ['./update-shop.component.scss']
})
export class UpdateShopComponent implements OnInit {

  constructor(private shopService : ShopService, private location:Location) { }

  public shop : Shop = {} as Shop
  ngOnInit(): void {
   this.shop = history.state
  }

  updateShop(id:number, title : string){
    this.shop.name = title
    this.shopService.updateShop(id, this.shop).subscribe(log => console.log('updated '+id))
  }
}
