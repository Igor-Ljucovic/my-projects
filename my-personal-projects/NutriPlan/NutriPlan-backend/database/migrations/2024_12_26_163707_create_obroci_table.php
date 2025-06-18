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
        Schema::create('obroci', function (Blueprint $table) {
            $table->id();
            $table->date("datum");
            $table->string("tip");
            $table->foreignId("korisnik_id");
            $table->foreignId("recept_id");
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('obroci');
    }
};
