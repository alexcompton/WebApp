import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'todolist',
    template: require('./todolist.component.html')
})

export class TodoListComponent {
    public items: Item[];
    public http: Http;
    public activeTask: Item;

    constructor(http: Http) {
        this.http = http;
        this.getTable();
    }

    getTable(): void {
        this.http.get('/api/Item').subscribe(result => {
            let items = result.json();
            console.log('items', items);
            this.items = items;
        });
    };

    viewDetails(item: Item): void {
        this.activeTask = item;
    }

    updateTask(item: Item): void {
        let message = JSON.stringify(item);
        alert('update item logic:\n' + message);
    }
}

interface Item {
    id: string;
    name: string;
    description: string;
    isComplete: boolean;
}

export class NewItem {
    constructor(
        public name: string,
        public description: string,
        public isComplete: boolean,
        public id?: string
    ) { }
}