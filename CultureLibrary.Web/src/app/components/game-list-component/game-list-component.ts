import {Component, inject} from '@angular/core';
import {GameService} from '../../shared/api-game-service';
import {rxResource} from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-game-list-component',
  imports: [],
  templateUrl: './game-list-component.html',
  styleUrl: './game-list-component.scss',
})
export class GameListComponent {
  #gameService = inject(GameService);

  readonly gamesResource = rxResource({
    stream: () => this.#gameService.apiGameGet()
  })
}
