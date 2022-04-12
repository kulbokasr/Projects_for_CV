import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import ShopCreate from 'src/app/models/shop-create.model';
import { ShopService } from 'src/app/services/shop.service';

@Component({
  selector: 'app-shop-create',
  templateUrl: './shop-create.component.html',
  styleUrls: ['./shop-create.component.scss']
})
export class ShopCreateComponent implements OnInit {

  constructor(private shopService: ShopService, private router: Router) { }

  public title: string = '';

  ngOnInit(): void {
  }

  public submitShop() : void {
    let shopCreate : ShopCreate = {
      name : this.title
    };

    this.shopService.createShop(shopCreate).subscribe(() => {
      console.log("Shop was created")
    });
    setTimeout(() => {
      this.router.navigate(['shop-list']);
  }, 100);
    
      
  }

}
