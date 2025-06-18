<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('alergije', function (Blueprint $table) {
            $table->unsignedBigInteger('korisnik_id');
            $table->unsignedBigInteger('namirnica_id');
            $table->foreign('namirnica_id')->references('id')->on('namirnice');
            $table->foreign('korisnik_id')->references('id')->on('korisnici');
            $table->primary(['korisnik_id', 'namirnica_id']);
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('alergije');
    }
};
