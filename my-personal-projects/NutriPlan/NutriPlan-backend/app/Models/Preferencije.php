<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Preferencije extends Model
{
    /** @use HasFactory<\Database\Factories\PreferencijeFactory> */
    use HasFactory;

    protected $table = 'preferencije';
    protected $fillable =
    [
        'naziv'
    ];
}
