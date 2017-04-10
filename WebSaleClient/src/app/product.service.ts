import { Injectable } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Observable, BehaviorSubject } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Product } from './product';
import { environment } from '../environments/environment';

@Injectable()
export class ProductService {

   constructor(
     private http: Http
   ){

   }

  public getProducts(): Promise<Product[]> {
    let params = new URLSearchParams();
    params.set('apiKey', '');
    params.set('source','all');
    return this.http
            .get(`${environment.baseUrl}${environment.paramPath}`,{search: params})
            .toPromise()
            .then(resp=> resp.json().value)
            .then(json=>{
              console.log('json->',json);
              return json;
            })
            .catch(err=>{
              console.log('We got an error', err);
            });
  }
}

