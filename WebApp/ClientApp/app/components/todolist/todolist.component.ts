import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'todolist',
    template: require('./todolist.component.html')
})
export class TodoListComponent {
    public items: Item[];

    constructor(http: Http) {
        http.get('/api/Item').subscribe(result => {
            this.items = result.json();
        });
    }
}

interface Item {
    id: string;
    name: string;
    description: string;
    completed: boolean;
}