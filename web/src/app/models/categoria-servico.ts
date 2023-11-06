export class CategoriaServico {
    Id: number;
    Descricao: string = '';

    constructor(id: number, descricao: string)
    {
        this.Id = id;
        this.Descricao = descricao;
    }

}
