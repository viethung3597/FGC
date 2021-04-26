import { Injectable } from '@angular/core';
import { PurchaseOrderDetail } from '../models/purchase-order-detail';
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class purchaseOrderDetailService {

  constructor(private http: HttpClient) {

  }

  purchaseOrderDetail!: PurchaseOrderDetail[];

  getData(startValue: string, endValue: string, pageIndex: string, pageSize: string): Promise<PurchaseOrderDetail[]> {

    const params = new HttpParams()
      .set('startValue', startValue)
      .set('endValue', endValue)
      .set('pageIndex', pageIndex)
      .set('pageSize', pageSize)

    return this.http
      .get('/api/PurchaseOrderDetail', {
        params: params
      })
      .toPromise()
      .then((res) => {
        this.purchaseOrderDetail = res as PurchaseOrderDetail[];
        // console.log(this.purchaseOrderDetail);
        return this.purchaseOrderDetail;
      });
  }

  getDataId(startValue: string, endValue: string, id: string): Promise<PurchaseOrderDetail[]> {

    const params = new HttpParams()
      .set('startValue', startValue)
      .set('endValue', endValue)
      .set('id', id);

    return this.http
      .get('/api/PurchaseOrderDetail/product', {
        params: params
      })
      .toPromise()
      .then((res) => {
        this.purchaseOrderDetail = res as PurchaseOrderDetail[];
        // console.log(this.purchaseOrderDetail);
        return this.purchaseOrderDetail;
      });
  }
  
}

