import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface InventoryDetail {
  itemID: number;
  name: string;
  description: string;
  quantity: number;
  price: number;
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7164/api/Detail'; // URL to web api
  constructor(private http: HttpClient) {}

  getItems(): Observable<InventoryDetail[]> {
    return this.http.get<InventoryDetail[]>(this.apiUrl);
  }

  getItem(id: number): Observable<InventoryDetail> {
    return this.http.get<InventoryDetail>(`${this.apiUrl}/${id}`);
  }

  createItem(item: InventoryDetail): Observable<InventoryDetail> {
    return this.http.post<InventoryDetail>(this.apiUrl, item);
  }

  updateItem(id: number, item: InventoryDetail): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, item);
  }

  deleteItem(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
