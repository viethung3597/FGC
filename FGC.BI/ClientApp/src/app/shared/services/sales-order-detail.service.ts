import { Injectable } from '@angular/core';
import { SalesOrderDetail } from '../models/sales-order-detail';
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({providedIn: 'root'})
export class salesOrderDetail {
    constructor(private http: HttpClient) { }
    
    salesOrderDetail!: SalesOrderDetail[];

    getDataSale(startValue: string, endValue: string , pageIndex: string, pageSize: string): Promise<SalesOrderDetail[]> {

        const params = new HttpParams()
          .set('startValue', startValue)
          .set('endValue', endValue)
          .set('pageIndex', pageIndex)
          .set('pageSize', pageSize)
    
        return this.http
          .get('/api/SalesOrderDetail', {
            params: params
          })
          .toPromise()
          .then((res) => {
            this.salesOrderDetail = res as SalesOrderDetail[];
            return this.salesOrderDetail;
          });
      }

      getDataId(startValue: string, endValue: string, id: string): Promise<SalesOrderDetail[]> {

        const params = new HttpParams()
          .set('startValue', startValue)
          .set('endValue', endValue)
          .set('id', id);
    
        return this.http
          .get('/api/SalesOrderDetail/detail', {
            params: params
          })
          .toPromise()
          .then((res) => {
            this.salesOrderDetail = res as SalesOrderDetail[];
            // console.log(this.purchaseOrderDetail);
            return this.salesOrderDetail;
          });
      }



}