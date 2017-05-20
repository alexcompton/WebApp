import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'todolist',
    template: require('./todolist.component.html')
})

export class TodoListComponent {
    public items: Item[];
    public http: Http;
    public activeItem: Item;

    constructor(http: Http) {
        this.http = http;
        this.getTable();
    }

    getTable(): void {
        this.http.get('/api/Item').subscribe(result => {
             this.items = result.json();
        });
    };

    btnDetails(item: Item): void {
        this.activeItem = item;
    }
}

interface Item {
    id: string;
    name: string;
    description: string;
    completed: boolean;
}

export class NewItem {
    constructor(
        public name: string,
        public description: string,
        public completed?: boolean,
        public id?: string
    ) { }
}