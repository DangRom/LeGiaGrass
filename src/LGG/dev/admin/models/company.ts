import Article = require('./article');

export class Company {
    id: number;
    name: string;
    sologan: string;
    hotline: string;
    email: string;
    website: string;
    timeWork: string;
    address: string;
    logo: string;
    avatar: string;

    facebook: string;
    twitter: string;
    google: string;
    linkedIn: string;
    instagram: string;
    pinterest: string;

    about: Article.Article;
    privacy: Article.Article;
    termsOfUse: Article.Article;
}