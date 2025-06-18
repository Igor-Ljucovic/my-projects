<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Obrok extends Model
{
    protected $table = 'obroci';
    protected $fillable =
    [
        'datum',
        'tip',
        'korisnik_id',
        'recept_id'
    ];

    use HasFactory;

    public function korisnik() {
        return $this->belongsTo(Korisnik::class);
    }
    public function recept() {
        return $this->belongsTo(Recept::class);
    }
}
