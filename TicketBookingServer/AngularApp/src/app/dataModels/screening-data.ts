import { Movie } from './movie'
import { Theatre } from './theatre'

export class ScreeningData {
  public screeningId!: number;
  public movieId!: number;
  public movie!: Movie;
  public theatreIdNumber!: number;
  public theatre!: Theatre;
  public screeningDateTime!: Date;
  public endDateTime!: Date;
}
