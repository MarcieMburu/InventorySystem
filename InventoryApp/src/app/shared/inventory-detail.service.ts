import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { InventoryItem } from './inventory-detail.model';
import { NgForm } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class InventoryItemService {

  url: string = environment.apiBaseUrl + '/InventoryItem'
  list: InventoryItem[] = [];
  formData: InventoryItem = new InventoryItem()
  formSubmitted: boolean = false;
  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as InventoryItem[]
        },
        error: err => { console.log(err) }
      })
  }

  postInventoryDetail() {
    return this.http.post(this.url, this.formData)
  }

  putInventoryDetail() {
    return this.http.put(this.url + '/' + this.formData.itemID, this.formData)
  }


  deleteInventoryDetail(id: number) {
    return this.http.delete(this.url + '/' + id)
  }


  resetForm(form: NgForm) {
    form.form.reset()
    this.formData = new InventoryItem()
    this.formSubmitted = false
  }
}
